# Update 2021-09-24
- Added LOD for terrain generation

*\*This introduces a seam at chunk borders between different LODs, leaving it as such for now because I plan to implement LODs in the terrain shader as well and just offset the vert positions in the opposite of their normal direction. But it might be better to do it in the marching cubes compute shader directly, so that the colliders are correct as well.*

# Procedural-Terrain using Marching Cubes
So far I've extended Sebastian's Marching Cubes project to calculate gradient normals.
Updated the project to Unity 2020.2.18f1 (LTS) and implemented kolop315's fix for the lookup tables.

![Smooth Normals](https://i.imgur.com/pzNVoEF.png)

Future plans:

- <strike>LOD</strike>

- Create a class to hold and serialize the world data so that it can be edited and saved.

- Realtime editing with brushes

- Extend the density generator to support different noise settings/types based on biome, and to generate voxel 'material' data as well, to be written to vertex colors of the mesh.

- Connected components algorithm to get rid of floating blocks in initial world generation.

- Erosion

- Proper terrain shader with some fancy texture tiling to break up repetition and height blending between materials, probably going to first port the project to URP at some point since I'm more familiar with shader graph than standard shaders, and try to implement MinionsArt's tesselation shaders to add some more detail to the terrain and maybe grass and snow.
