# Marching-Cubes
So far I've extended Sebastian's Marching Cubes project to calculate gradient normals.
Updated the project to Unity 2020.2.18f1 (LTS) and implemented kolop315's fix for the lookup tables.

![Smooth Normals](https://i.imgur.com/pzNVoEF.png)

Future plans:

-LOD

-Create a class to hold and serialize the world data so that it can be edited and saved.

-Realtime editing with brushes

-Extend the density generator to support different noise settings/types based on biome, and to generate voxel 'material' data as well, which will be written to vertex colors of the mesh.

-Implement connected components algorithm to get rid of floating blocks in initial world generation.

-Erosion

-Proper terrain shader with some fancy texture tiling to break up repetition and height blending between materials, probably going to port to URP at some point since I'm more familiar with shader graph than standard shaders, and try to implement MinionsArt's grass and tesselation shaders to add some more detail to the terrain and grass and snow.
