using System;
using System.IO;
using NLua;

namespace KVSV.Metaverse
{   
    public class Script
    {
        public Lua state { get; set; }
        public string code { get; private set; }
        
        public Script(string scriptPath) {
            state = new();
            code = File.ReadAllText(scriptPath);
        }
        
        public void Start() {
            state.LoadCLRPackage();
            state.DoString(@"import('Metaverse', 'KVSV.Metaverse')
                           --import = function() end");

            state.DoString(code);
            
            var start = state["Start"] as LuaFunction;
            var update = state["Update"] as LuaFunction;
            
            start.Call();

            Console.WriteLine(state["x"]);
        }

        public void Update(float deltaTime) {
            state.LoadCLRPackage();
            state.DoString(@"import('Metaverse', 'KVSV.Metaverse')
                           --import = function() end");
            state.DoString(code);
            state["deltaTime"] = deltaTime;
            var update = state["Update"] as LuaFunction;
            update.Call();
        }
    }
}
