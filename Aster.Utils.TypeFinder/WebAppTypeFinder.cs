using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Aster.Utils.TypeFinder
{
    public class WebAppTypeFinder : AppDomainTypeFinder {
        

        private bool _ensureBinFolderAssembliesLoaded = true;
        private bool _binFolderAssembliesLoaded;

        

        
        public bool EnsureBinFolderAssembliesLoaded {
            get { return _ensureBinFolderAssembliesLoaded; }
            set { _ensureBinFolderAssembliesLoaded = value; }
        }

        
        /// <summary>
        /// Gets a physical disk path of \Bin directory
        /// </summary>
        /// <returns>The physical path. E.g. "c:\inetpub\wwwroot\bin"</returns>
        public virtual string GetBinDirectory() {
            return AppContext.BaseDirectory;
        }

        
        public override IList<Assembly> GetAssemblies() {
            if(this.EnsureBinFolderAssembliesLoaded && !_binFolderAssembliesLoaded) {
                _binFolderAssembliesLoaded = true;
                var binPath = GetBinDirectory();
                //binPath = _webHelper.MapPath("~/bin");
                LoadMatchingAssemblies(binPath);
            }

            return base.GetAssemblies();
        }
    }
}
