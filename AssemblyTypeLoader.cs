using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace KVSV.Metaverse {
public static class AssemblyTypeLoader {
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly) {
            if(assembly == null) throw new ArgumentNullException("assembly");
            try {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e) {
                return e.Types.Where(t => t != null);
            }
        }
    }
}