=== SPRITE LIST ===

-- BASIC --
 1. idle (looping)

 2. run (looping)

-- COMBAT --
 3. melee (looping)
   > Basic melee swipe
   > Contains fx

 4. slam (one shot)
   > Single book slam
   > Contains fx

 5. block (one shot)
   > Block/Shield, with recovery

 6. block knockback (one shot)
   > Knockback after taking damage during a block

 7. hurt (one shot)
   > Basic hurt frame

-- JUMP --
 8. jump (one shot)
   > Jump and fall animation

 9. jump melee (looping)
   > Jump version of the melee sprite
   > Contains fx

 10. jump slam (one shot)
   > Jump version of the slam sprite
   > Contains fx

 11. jump block (one shot)
   > Jump version of the block sprite


=== FOLDERS ===

 1. spritesheets: Standard spritesheets for each animation
 2. individual images: Separate PNG image files of each sprite frame organized into folders
 3. animated GIFs: Animated gifs of each animation for reference
 4. aseprite files: Aseprite files with the original layers for those who want more editing capabilities


=== NOTE ===
Anchor/pivot points are centered! All sprites have the same height, but width may wary.

Melee and slam sprites come in sets of three: the full sprite, the base character (char) sprite, and the effects (fx) sprite. 
The full sprite is the original sprite, and the char and fx sprite is split into the character and the effects in case you need it for layering or hitboxes.

=== COPYRIGHT ===

Kosuzu Motoori, Forbidden Scrollery, and the Touhou Project is the property of ZUN. Refer to his guidelines for proper fan project rules: https://touhou-project.news/guidelines_en/
