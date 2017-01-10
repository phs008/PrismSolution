using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRCAT.DataModel
{
    /// <summary>
    /// Directory , File Watcher Extender Class
    /// </summary>
    public class AssetDirecotryWatcher : FileSystemWatcher
    {
        /// <summary>
        /// Watcher Extender Class 생성자
        /// </summary>
        /// <param name="RootPath">Directory , File 생성,삭제,이름변경등을 탐색할 RootPath</param>
        public AssetDirecotryWatcher(string RootPath)
            : base(RootPath) { }
        /// <summary>
        /// Watcher Type
        /// </summary>
        /// <remarks>Directory : 디렉토리 시스템 만 확인</remarks>
        /// <remarks>File : 파일 시스템 만 확인</remarks>
        public enum WatcherType { Directory, File };
        WatcherType _watcher;
        /// <summary>
        /// Watcher Type 설정
        /// </summary>
        /// <example>Watcher = WatcherType.Directory</example>
        public WatcherType Watcher
        {
            get { return _watcher; }
            set { _watcher = value; }
        }
    }
}
