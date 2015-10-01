using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CameraLib
{
    public class VideoStore
    {
        private string rootDir;
        private string currentWorkingDir;
        private string currentWorkingFile;
        private DateTime lastCreateDirDate;
        private DateTime lastCreateFileDate;
        public VideoStore(string rootDir)
        {
            this.rootDir = rootDir;
        }

        public string GetStoreName()
        {
            var workingDir = GetWorkingDir();
            var now = DateTime.Now;
            if (lastCreateFileDate.AddMinutes(5) < now)
            {
                currentWorkingFile = string.Format(@"{0}\{1}.avi", workingDir, TimeUtil.ToTimestamp(now));
                lastCreateFileDate = now;
            }
            return currentWorkingFile;
        }

        public void Save(string fileName)
        {
            var destFileName = fileName.Replace(".avi", ".cam");
            try
            {
                File.Move(fileName, destFileName);
            }
            catch (Exception ex)
            {
                //todo
            }
            lastCreateFileDate = DateTime.MinValue;
        }

        public IEnumerable<string> GetAllVideoFiles(DateTime date)
        {
            IEnumerable<string> files = null;
            var dir = string.Format(@"{0}\{1}", rootDir, date.ToString("yyyyMMdd"));
            var fileOffsets = GetAllVideoFileOffsets(date, dir);
            if (fileOffsets != null && fileOffsets.Length >= 1)
            {
                files = fileOffsets.Select(f => string.Format(@"{0}\{1}.cam", dir, f));
            }
            return files;
        }

        public string[] LookupVideoFile(DateTime date, long offset)
        {
            string[] storeNames = null;
            var dir = string.Format(@"{0}\{1}", rootDir, date.ToString("yyyyMMdd"));
            var fileOffsets = GetAllVideoFileOffsets(date, dir);
            if (fileOffsets != null && fileOffsets.Length >= 1)
            {
                var idx = Array.BinarySearch<long>(fileOffsets, offset);
                if (idx <= 0)
                    idx = ~idx;
                if (idx < fileOffsets.Length)
                {
                    //如果下一个视频距离这次视频偏移不到10秒钟，在播放的时候，把下一个视频也带上来。
                    if (fileOffsets[idx] - offset <= 10)
                    {
                        if (idx == 0)
                            storeNames = new string[] { string.Format(@"{0}\{1}.cam", dir, fileOffsets[idx]) };
                        else
                            storeNames = new string[] { string.Format(@"{0}\{1}.cam", dir, fileOffsets[idx - 1]), string.Format(@"{0}\{1}.cam", dir, fileOffsets[idx]) };
                    }
                    else
                    {
                        if (idx >= 1)
                        {
                            storeNames = new string[] { string.Format(@"{0}\{1}.cam", dir, fileOffsets[idx - 1]) };
                        }
                    }
                }
                else
                {
                    //如果用户刷卡时间在最后一个视频范围内(5分钟)，则返回这个视频
                    if (offset - fileOffsets[fileOffsets.Length - 1] <= 5 * 60)
                    {
                        //并且当前没有一个比他时间点更近的avi文件正在生成，如果有放弃返回
                        var tempFileOffsets = GetAllVideoFileOffsets(date, dir, "avi");
                        foreach (var o in tempFileOffsets)
                        {
                            if (offset > o)
                                return storeNames;
                        }

                        storeNames = new string[] { string.Format(@"{0}\{1}.cam", dir, fileOffsets[fileOffsets.Length - 1]) };
                    }
                }
            }
            return storeNames;
        }

        private string GetWorkingDir()
        {
            var date = DateTime.Now.Date;
            if (lastCreateDirDate != date)
            {
                var dir = string.Format(@"{0}\{1}", rootDir, date.ToString("yyyyMMdd"));
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                lastCreateDirDate = date;
                currentWorkingDir = dir;
            }
            return currentWorkingDir;
        }

        private long[] GetAllVideoFileOffsets(DateTime date, string dir, string extensionName = "cam")
        {
            long[] fileOffsets = null;
            if (Directory.Exists(dir))
            {
                var directory = new DirectoryInfo(dir);
                fileOffsets = directory
                    .GetFiles(string.Format("*.{0}", extensionName))
                    .Select(f =>
                    {
                        long val = 0;
                        long.TryParse(f.Name.Replace(string.Format(".{0}", extensionName), string.Empty), out val);
                        return val;
                    })
                    .Where(off => off != 0)
                    .OrderBy(off => off)
                    .ToArray();
            }
            return fileOffsets;
        }
    }
}
