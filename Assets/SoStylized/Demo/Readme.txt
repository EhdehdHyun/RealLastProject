Check out the full official documentation here:
https://docs.google.com/document/d/1DO2epMFrkPEauO7-2zf-KXt_M1oRlx9PGnAMT3Iy8Js/edit?usp=sharing



SETUP
Built-in, URP, HDRP
The Unity assets are designed for URP. There should be assets in the Settings folder of the URP_Asset, URP_GS, and URP_Renderer. 



ENVIRONMENT ASSETS

Trees
Trees, as well as some foliage and rocks, can be placed either by hand or using the built in Unity Paint Trees placement tool. Be sure to read the section on Collision Issues to know what differences you will face using each method. With hand-placed trees, the full complex collision can be used which allows for proper tree climbing and collision on individual branches. 

The main look of the trees will be adjusted in the Material or Material Variant of the main tree type. For example to adjust the look of Oak Trees, we can navigate to SoStylized > Environment > Trees > Materials > M_OakLeaves. 

Rocks
Rocks are similar to trees, but most of them should probably be placed by hand due to the Collision Issues mentioned. Small rocks that need no collision could be painted.

Larger cliffs are designed to be placed alongside terrain to make the terrain look less “terrain sculpted” and more natural and epic. You can see this in use in the demonstration levels. 

Water
The water is honestly a bonus that I wasn’t initially going to include at all, but I gave it my best shot and ended up being actually quite happy with how it looked! 

There is no underwater post processing effects or water ripples, so it’s meant more of a visual to be used either at a distance, or a shader to be used in conjunction with other packs. I did want to include it though because I just loved the look of it so much <3
Sky
The sky is made up of a few layers of clouds each moving at different speeds. 

The prefab includes a directional light which has already been calibrated to fit the intended lighting of the assets. You are welcome to remove it and use your own.



TROUBLESHOOTING
Collision Issues
Ok so real talk for a second— I didn’t realize until after making both demonstration maps that Unity does not support complex collision on meshes placed using the Paint Trees tool, unlike in other game engines. This created an issue which I mostly solved but I’d like to clarify what’s going on!

As I just mentioned, Paint Trees meshes do not support custom collision. This means that if you were to paint P_OakTree01, you will not be able to climb around on this oak tree in game. In fact by default you would just clip right through it. However, Painted Tess do support capsule collision. So as a solution, you’ll notice many of the tree prefabs have a capsule collision on LOD0 which allows players to collide with trees painted onto your landscape. 


Now you might be thinking- that’s nice to fix the painted trees, but won’t I bump into this capsule which bulges out weirdly when trying to climb on hand-placed trees? I’ve got you covered, and you’ll notice these LODs have a C# script I wrote which will remove the capsule collision if the tree is hand-placed, and thus only use the custom collision! Yay!

Some trees that are too curvy/twisted weren’t able to be approximated with a capsule collision, and thus I didn’t bother adding one. These trees simply should not be painted and should all be hand placed. Unfortunately like I mentioned before, I didn’t know that at first, so you may find some still on the demo levels, just don’t make the same mistake I did and you’ll be fine!

If you have any more Unity knowledge on this subject and know a better solution, please let me know. I’ve mostly just seen posts that it isn’t possible:
Trees painted with the terrain don’t have collision but the prefabs they use do : r/Unity3D

No Grass on Cliffs/Shelves
You’ll notice the rock shelves/cliffs often don’t have any grass meshes on them. This is unfortunately a feature not supported by Unity’s foliage painting tools. 


Luckily, after reading into it, it seems there are many custom solutions/plugins, both free and paid, which you could look into. Obviously I can’t provide these in my pack, but you can read some of the discussion here:
Can we paint a grass and tree on a 3D mesh? - Getting Started - Unity Discussions
How to do grass on a mesh efficiently? : r/Unity3D
Is there a way I can paint grass or trees on this Mesh given to me by the client? I tried creating a terrain with the shape of it but it doesn't look the same. What are my choices? : r/Unity3D

Alternatively, I provided a larger Grass3 model which can be placed in these areas if it’s not too large of a space. 


Ambient Occlusion Issues
You might notice the Ambient Occlusion being weird around the corners of the screen or inside bushes/foliage sometimes.

Unfortunately this just seems to be a result of how Ambient Occlusion is rendered inside Unity. I really wanted to use AO as a method of shading cliffs in the distance, but the more I did so would cause more glitches in the corner. I ended up going for something in the middle.

If you want to further fix it, you can go into SoStylized > Settings > URP_Renderer and change some settings there. Radius and Intensity will be the most noticeably. But you’ll also notice cliffs in the distance will appear more flat.




PERFORMANCE
The assets will always have 999+ FPS in all scenes on all devices! 

Just kidding, as much as I wish this were true and I prioritized performance when designing the assets, nothing will work for every situation.

Here are some tips on improving performance.
URP Settings
You can adjust some global URP related rendering settings in SoStylized > Settings > URP_Asset


I would recommend reading up on what these all do if you’re unfamiliar, but I can say one of the most common things I find myself tweaking is the Shadows Max Distance. 

Material Features
Another easy way to improve performance is to disable certain features on materials.

If you ever see any checkbox in the parameters section of a material, you could potentially disable that for slight increases in shader performance. For instance, in M_OakLeaves we could disable UseWind? and get a bit better performance from oak trees.


Terrain Details
We can also lower rendering distances of terrain details by selecting the Terrain, going to the tab on the far right, and lowering the Detail Distance (currently 150.)

