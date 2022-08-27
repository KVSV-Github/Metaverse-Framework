using StereoKit;
using System;
using System.Collections.Generic;

namespace VRProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initialize StereoKit
            SKSettings settings = new SKSettings
            {
                appName = "VRProject",
                assetsFolder = "Assets",
            };
            if (!SK.Initialize(settings))
                Environment.Exit(1);

            #region Test Entities
            /*

            #region Grab Cube Entity

            Entity grabbableCube = new("Grab Cube");

            TransformComponent grabCubeTransform = new();
            grabCubeTransform.transform = new Pose(0, 0, -0.5f, Quat.Identity).ToMatrix();

            ModelComponent grabCubeModel = new();
            grabCubeModel.mesh = Mesh.GenerateRoundedCube(Vec3.One * 0.1f, 0.02f);
            grabCubeModel.material = Material.Default;

            GrabbableComponent grabCubeGrabbable = new();

            grabbableCube.AddComponent(grabCubeTransform);
            grabbableCube.AddComponent(grabCubeModel);
            grabbableCube.AddComponent(grabCubeGrabbable);

            #endregion

            #region Background Music Entity
            Entity bgMusic = new Entity("Background Music");

            SoundComponent bgSound = new();
            bgSound.soundFile = "outInSpace.mp3";
            bgSound.volume = 0.1f;

            TransformComponent bgMusicTransform = new();
            bgMusicTransform.transform = Matrix.T(0, 1, 0);

            bgMusic.AddComponent(bgSound);
            bgMusic.AddComponent(bgMusicTransform);

            #endregion

            #region Floor Entity

            Entity floor = new("Floor");

            TransformComponent floorTransform = new();
            floorTransform.transform = Matrix.TS(0, -1.5f, 0, new Vec3(30, 0.1f, 30));

            ModelComponent floorModel = new();
            floorModel.mesh = Mesh.Cube;
            floorModel.material = new Material(Shader.FromFile("floor.hlsl"));
            floorModel.material.Transparency = Transparency.Blend;

            floor.AddComponent(floorTransform);
            floor.AddComponent(floorModel);

            HashSet<Type> components = new();
            foreach(IComponent component in floor.Components)
            {
                components.Add(component.GetType());
            }
            archetypeManager.AddToArchetype(floor.uuid, components);

            #endregion

            */

            #endregion

            // Core application loop
            while (SK.Step(() =>
            {
                World.Instance.Update();
            })) ;
            SK.Shutdown();
        }
    }
}
