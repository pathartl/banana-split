﻿using BananaSplit.Extensions;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace BananaSplit
{
    public partial class MainForm : Form
    {
        private SettingsForm SettingsForm;

        private List<QueueItem> QueueItems { get; set; }
        private Thread ScanningThread;
        private Thread ProcessingThread;
        private FFMPEG FFMPEG;
        private MKVToolNix MKVToolNix;

        private string[] SupportedExtensions =
        {
            ".avi",
            ".flv",
            ".m4p",
            ".m4v",
            ".mkv",
            ".mov",
            ".mp2",
            ".mp4",
            ".mpe",
            ".mpeg",
            ".mpg",
            ".mpv",
            ".ogg",
            ".ts",
            ".webm",
            ".wmv"
        };

        public MainForm()
        {
            InitializeComponent();
            QueueItems = new List<QueueItem>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Menu Items
            AddFilesToQueueMenuItem.Click += AddFilesToQueueDialog;
            AddFolderToQueueMenuItem.Click += AddFolderToQueueDialog;
            SettingsMenuItem.Click += OpenSettingsForm;

            // Queue List
            QueueList.SelectedIndexChanged += RenderReferenceImagesListView;
            QueueList.MouseUp += OpenQueueItemContextMenu;
            QueueItemContextMenuProcess.Click += ProcessQueueItem;
            QueueItemContextMenuRemove.Click += RemoveQueueItem;
            QueueListContextMenuProcess.Click += ProcessQueue;
            QueueListContextMenuRemove.Click += RemoveQueueList;

            // Other
            ProcessQueueButton.Click += ProcessQueue;
            QueueList.Resize += AutoSizeQueueList;

            SettingsForm = new SettingsForm();

            FFMPEG = new FFMPEG();
            MKVToolNix = new MKVToolNix();
        }

        private void AutoSizeQueueList(object sender, EventArgs e)
        {
            QueueList.Columns[0].Width = QueueList.Width - 4;
        }

        private void OpenQueueItemContextMenu(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && QueueList.FocusedItem != null && QueueList.FocusedItem.Bounds.Contains(e.Location))
            {
                QueueItemContextMenu.Tag = QueueList.FocusedItem.Tag;
                QueueItemContextMenu.Show(Cursor.Position);
            }
            else if (e.Button == MouseButtons.Right)
            {
                QueueListContextMenu.Show(Cursor.Position);
            }
        }

        private void AddFilesToQueueDialog(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = $"Video Files (*{String.Join(",*", SupportedExtensions)})|*{String.Join(";*", SupportedExtensions)}";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    QueueItems.AddRange(openFileDialog.FileNames.Select(fn => new QueueItem(fn)));

                    ScanningThread = new Thread(() => {
                        ScanQueueItems();
                    });

                    ScanningThread.Start();
                }
            }
        }

        private void AddFolderToQueueDialog(object sender, EventArgs e)
        {
            using (FolderBrowserDialog openFolderDialog = new FolderBrowserDialog())
            {
                var result = openFolderDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(openFolderDialog.SelectedPath))
                {
                    string[] files = Directory.GetFiles(openFolderDialog.SelectedPath);

                    foreach (var file in files)
                    {
                        if (SupportedExtensions.Contains(Path.GetExtension(file)))
                        {
                            QueueItems.Add(new QueueItem(file));
                        }
                    }

                    ScanningThread = new Thread(() => {
                        ScanQueueItems();
                    });

                    ScanningThread.Start();
                }
            }
        }

        private void ScanQueueItems()
        {
            SetStatusBarProgressBarValue(0, QueueItems.Count);

            var i = 0;

            foreach (var item in QueueItems.Where(qi => !qi.Scanned))
            {
                i++;

                SetStatusBarProgressBarValue(i, QueueItems.Count);
                SetStatusBarLabelValue($"Detecting frames for {Path.GetFileName(item.FileName)}");
                item.Scanned = true;
                item.LastScanned = DateTime.Now;
                item.BlackFrames = FFMPEG.DetectBlackFrames(item.FileName);
                item.Duration = FFMPEG.GetDuration(item.FileName);

                foreach (var frame in item.BlackFrames)
                {
                    long offset = (long)(SettingsForm.Settings.ReferenceFrameOffset * TimeSpan.TicksPerSecond);
                    TimeSpan referenceFramePosition = frame.End.Add(new TimeSpan(offset));

                    SetStatusBarLabelValue($"Generating frame at {referenceFramePosition}");
                    frame.ReferenceFrame = new ReferenceFrame();
                    frame.ReferenceFrame.Data = FFMPEG.ExtractFrame(item.FileName, referenceFramePosition);
                }

                AddItemToQueue(item);
            }

            SetStatusBarLabelValue("Done!");
            ClearStatusBarProgressBarValue();
        }

        private void SetStatusBarProgressBarValue(int value, int maximum)
        {
            StatusBar.Invoke(
                new MethodInvoker(
                    delegate () {
                        StatusBarProgressBar.Value = value;
                        StatusBarProgressBar.Maximum = maximum;
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Normal);
                        TaskbarManager.Instance.SetProgressValue(value, maximum);
                    }
                )
            );
        }

        private void ClearStatusBarProgressBarValue()
        {
            StatusBar.Invoke(
                new MethodInvoker(
                    delegate () {
                        StatusBarProgressBar.Value = 0;
                        StatusBarProgressBar.Maximum = 1;
                        TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);
                        TaskbarManager.Instance.SetProgressValue(0, 1);
                    }
                )
            );
        }

        private void SetStatusBarLabelValue(string value)
        {
            StatusBar.Invoke(
                new MethodInvoker(
                    delegate () {
                        StatusBarLabel.Text = value;
                    }
                )
            );
        }

        private void LockControls()
        {
            Invoke(
                new MethodInvoker(
                    delegate ()
                    {
                        ProcessQueueButton.Enabled = false;
                        QueueListContextMenuProcess.Enabled = false;
                        QueueItemContextMenuProcess.Enabled = false;
                        QueueListContextMenuRemove.Enabled = false;
                        QueueItemContextMenuRemove.Enabled = false;
                        AddFilesToQueueMenuItem.Enabled = false;
                        AddFolderToQueueMenuItem.Enabled = false;
                        Cursor.Current = Cursors.WaitCursor;
                    }
                )
            );
        }

        private void UnlockControls()
        {
            Invoke(
                new MethodInvoker(
                    delegate ()
                    {
                        ProcessQueueButton.Enabled = true;
                        QueueListContextMenuProcess.Enabled = true;
                        QueueItemContextMenuProcess.Enabled = true;
                        QueueListContextMenuRemove.Enabled = true;
                        QueueItemContextMenuRemove.Enabled = true;
                        AddFilesToQueueMenuItem.Enabled = true;
                        AddFolderToQueueMenuItem.Enabled = true;
                        Cursor.Current = Cursors.Default;
                    }
                )
            );
        }

        private void AddItemToQueue(QueueItem item)
        {
            QueueList.Invoke(
                new MethodInvoker(
                    delegate () {
                        QueueList.Items.Add(new ListViewItem()
                        {
                            Text = Path.GetFileName(item.FileName),
                            ToolTipText = item.FileName,
                            Name = item.Id.ToString(),
                            Tag = item
                        });
                    }
                )
            );
        }

        private void RenderReferenceImagesListView(object sender, EventArgs e)
        {
            if (QueueList.SelectedItems.Count > 0)
            {
                var selectedItem = (QueueItem)QueueList.SelectedItems[0].Tag;

                foreach (var frame in selectedItem.BlackFrames)
                {
                    if (frame.ReferenceFrame.Data.Length > 0)
                    {
                        var bmp = Utilities.BytesToImage(frame.ReferenceFrame.Data);

                        ReferenceImageList.Add(bmp, frame.Id.ToString());

                        ReferenceImageListView.Items.Add(new ListViewItem()
                        {
                            ImageKey = frame.Id.ToString(),
                            Tag = frame,
                            Name = frame.Id.ToString(),
                            Text = frame.End.ToString(),
                            Checked = frame.Selected
                        });
                    }
                }
            }
            else
            {
                ReferenceImageListView.Clear();
            }
        }

        private void OpenSettingsForm(object sender, EventArgs e)
        {
            SettingsForm.Show();
        }

        private void ReferenceImageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in ReferenceImageListView.Items)
            {
                if (item.Selected)
                {
                    item.Selected = false;
                    item.Checked = !item.Checked;

                    ((BlackFrame)item.Tag).Selected = item.Checked;
                }
            }
        }

        private void RemoveQueueItem(object sender, EventArgs e)
        {
            QueueItem queueItem = (QueueItem)QueueItemContextMenu.Tag;

            QueueList.Items.RemoveByKey(queueItem.Id.ToString());
            QueueItems.Remove(queueItem);
        }

        private void RemoveQueueList(object sender, EventArgs e)
        {
            foreach (var queueItem in QueueItems)
            {
                QueueList.Items.RemoveByKey(queueItem.Id.ToString());
            }

            QueueItems.Clear();
        }

        private void ProcessQueue(object sender, EventArgs e)
        {
            ProcessingThread = new Thread(() =>
            {
                LockControls();

                SetStatusBarProgressBarValue(0, QueueItems.Count);

                var i = 0;

                switch (SettingsForm.Settings.ProcessType)
                {
                    case ProcessingType.MatroskaChapters:
                        foreach (var queueItem in QueueItems)
                        {
                            i++;

                            SetStatusBarProgressBarValue(i, QueueItems.Count);
                            SetStatusBarLabelValue($"Adding chapters for {Path.GetFileName(queueItem.FileName)}");

                            ProcessMatroskaChapters(queueItem);
                        }

                        SetStatusBarLabelValue("Done adding chapters!");
                        break;

                    case ProcessingType.SplitAndEncode:
                        foreach (var queueItem in QueueItems)
                        {
                            i++;

                            SetStatusBarProgressBarValue(i, QueueItems.Count);
                            SetStatusBarLabelValue($"Encoding for {Path.GetFileName(queueItem.FileName)}");

                            ProcessSplitAndEncode(queueItem);
                        }

                        SetStatusBarLabelValue("Done encoding!");
                        break;
                }

                UnlockControls();
                
                ClearStatusBarProgressBarValue();
            });

            ProcessingThread.Start();
        }

        private void ProcessQueueItem(object sender, EventArgs e)
        {
            ProcessingThread = new Thread(() =>
            {
                QueueItem queueItem = (QueueItem)QueueItemContextMenu.Tag;

                LockControls();

                SetStatusBarProgressBarValue(1, 1);

                switch (SettingsForm.Settings.ProcessType)
                {
                    case ProcessingType.MatroskaChapters:
                        SetStatusBarLabelValue($"Adding chapters for {Path.GetFileName(queueItem.FileName)}");
                        ProcessMatroskaChapters(queueItem);
                        SetStatusBarLabelValue("Done adding chapters!");
                        break;

                    case ProcessingType.SplitAndEncode:
                        SetStatusBarLabelValue($"Encoding for {Path.GetFileName(queueItem.FileName)}");
                        ProcessSplitAndEncode(queueItem);
                        SetStatusBarLabelValue("Done encoding!");
                        break;
                }

                UnlockControls();

                ClearStatusBarProgressBarValue();
            });

            ProcessingThread.Start();
        }

        private void ProcessMatroskaChapters(QueueItem queueItem)
        {
            List<TimeSpan> chapterTimeSpans = new List<TimeSpan>();

            // Always add the beginning as a chapter
            chapterTimeSpans.Add(new TimeSpan(0, 0, 0));

            foreach (var frame in queueItem.BlackFrames.Where(bf => bf.Selected))
            {
                var halfDuration = new TimeSpan(frame.Duration.Ticks / 2);

                chapterTimeSpans.Add(frame.End.Subtract(halfDuration));
            }

            if (!FFMPEG.IsMatroska(queueItem.FileName))
            {
                var matroskaPath = MKVToolNix.RemuxToMatroska(queueItem.FileName);

                queueItem.FileName = matroskaPath;
            }

            var chapters = MKVToolNix.GenerateChapters(chapterTimeSpans);

            MKVToolNix.InjectChapters(queueItem.FileName, chapters);
        }

        private void ProcessSplitAndEncode(QueueItem queueItem)
        {
            var segments = queueItem.GetSegments();
            var index = 1;

            foreach (var segment in segments)
            {
                var newName = Path.Combine(Path.GetDirectoryName(queueItem.FileName), Path.GetFileNameWithoutExtension(queueItem.FileName) + "-" + index + ".mkv");

                FFMPEG.EncodeSegments(queueItem.FileName, newName, SettingsForm.Settings.FFMPEGArguments.Replace("\r\n", " "), segment);

                index++;
            }
        }
    }
}
