using System;
using System.IO;
using System.Collections.Generic;
using KVSV.Metaverse.DefaultComponents;
using NLua;

namespace KVSV.Metaverse
{   
    public class Script
    {
        private LuaFunction update;
        private LuaFunction start;
        
        Lua state = new();
        string code;
        
        public Script(string scriptPath) {
            code = File.ReadAllText(scriptPath);
        }
        
        public void Start() {
            state.LoadCLRPackage();
            state.DoString(@"import('VRProject', 'KVSV.Metaverse')
                           import('VRProject', 'KVSV.Metaverse.DefaultComponents')
                           --import = function() end");
            
            state.DoString(code);
            
            start = state["Start"] as LuaFunction;
            update = state["Update"] as LuaFunction;
            
            start.Call();
        }

        public void Update(float deltaTime) {
            state["deltaTime"] = deltaTime;
            update.Call();
        }
        
    }
}
