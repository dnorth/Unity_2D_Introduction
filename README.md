# Unity_2D_Introduction
Introduction to making a 2D platforming game in Unity

First you'll want to clone or download this repository and load it into Unity.

You do this by opening your version of Unity and while on the `Projects` page, clicking `OPEN` and finding the filepath where you saved the project and navigating and selecting the `2D_Intro` folder.

This project was built in Unity 5.5.0f3 and if your Unity version does not match, you'll get a little warning. Click `Continue` to allow Unity to import the project anyways. 

When it loads, you'll be looking at notice that there is a `Completed` folder where you can reference the completed scene, scripts, sprites and animations if you ever need to. 

You should also see `Animations`, `Scenes`, `Scripts`, and `Sprites` folders. This is where we'll add our files while we're working on this project. 

Let's start off by looking at the `Sprites` folder. We have a few sample sprites to use and for the project we'll only be using the `background`, `platform`, and `spelunky` sprites but the others are provided for convenience if you wanted to enhance the project. 
  * When you click on a sprite and look at the `Inspector` tab, you'll notice that the `Pixels Per Unit` has been changed to 128. The default is 100 and there is no problem with either, but I prefer to change my `Pixels Per Unit` to powers of 2. 
  
By default, the `Game` tab might be the main tab selected, but while we're working on the project let's make sure the `Scene` tab is being shown for us. 

The first item we'll want for our platformer is a background. This is as easy as dragging the `background` sprite to the `Hierarchy` tab, which will create a new Game Object called `background` and you can see in the `Inspector` tab that this has a few components. Notably, a `Transform` and a `Sprite Renderer`. 
  * Every Game Object in Unity has a Transform, and the rest of the components are optional!
  
You should see the background image in your Scene view. Take notice of the scene view and the white-outlined box with a camera logo in the middle. This is what your camera will see when you start your game. Since we want our background to be _BIGGER_ than our camera view, we'll have to manipulate this image. 

With the `background` image selected in the `Hierarchy` view, look over to the `Inspector` tab and change the `Scale` of the image. You can test out different values that work for you, but I changed my scale to `X: 3, Y: 1.5, Z: 1` and it is now sufficiently large enough to cover the camera boundaries.

If you click anywhere in the `Scene` view and then scroll out, you can see the entire object that is the same image you had before, but scaled to a larger size. 

Now that we have a background, we're going to want to add some kind of platform for our hero to stand on. Let's go back to the `Sprites` folder in the `Project` view and click on the `platform` sprite. 

Unlike the `background`, we can't just drag and drop the `platform` sprite wholesale. You'll notice that there are actually multiple platforms in this image and we want to break them apart. 

With the `platform` image selected, go to the `Inspector` tab and update the `Sprite Mode` property on this sprite. The default is single, meaning Unity assumes this sprite is a single image. Since we know it's not, let's update the mode to `Multiple` so that Unity knows that we want to seperate this sprite into multiple sprites.

Find the `Sprite Editor` button in that same `Inspector` view and click on it. 
  * If you get a message about Unapplied import settings, go ahead and click Apply

A new `Sprite Editor` window should pop up with an enlarged version of your sprite. On the top left, there should be a dropdown menu called `Slice` that we will click. This menu will help us slice our sprite into multiple sprites with a helpful tool.

Once the `Slice` menu is open, you'll notice a few settings. For the platforms, these default settings are fine. Go ahead and click `Slice` at the bottom of the window. Unity will automatically find the borders of the images for us, and create a box that will surround each supposed sprite individually.

Each platform should now have its own box around it, and it's _REALLY_ hard to see, but if you look closely you'll notice it's there. Exit the menu. Once you're done being marveled at this awesome tool, click `Apply` (Top right corner) and then close the `Sprite Editor`. 

Now if you look in the `Project` view, you should see your single sprite and if you click on the arrow pointing to the right of the platform sprite, you'll see it is composed of 5 sub-sprites. Let's take the biggest platform, `platform_0` and add that to our scene. You can place it anywhere you think is good, but if you want a reference point, mine is starting at `X: -4, Y: -4, Z: 0`. You can change it to this position by clicking on the Game Object in the `Scene` or `Hierarchy` view. Now looking at the `Inspector` tab, change the `Transform -> Position` component to match the numbers given. 

You'll notice that part of the platform is inside the white-outlined camera boundaries and part of it is outside. Hit the `Play` button to see what this translates to once it loads in the game view.

You can see that the camera boundaries translate directly. In the game view, part of the platform is shown, and part of it is not. So if you place your platform on your own, just make sure that you place part of it _SOMEWHERE_ within the camera boundaries. 


Now that we've got our background and our first platform, let's get our hero setup! In the `Project` view again, let's go back to our `Sprites` folder and find the `spelunky` spritesheet. Again, we'll need to change its `Sprite Mode` to `Multiple` and then open up the `Sprite Editor`. 

The difference this time, however, is in how we're slicing. If we allow Unity to slice the sprites into their smallest sizes, then when we animate the sprites together, they will be different shapes and it will look wrong. So instead, when we open up the `Slice` menu, change the `Type` to `Grid By Cell Size`. This will allow us to cut this spritesheet up into images of the same size. 

With the new options that pop below where we selected, let's change `Pixel Size` to `X: 80, Y: 80` to create an 80x80 image. This is just the right size to split our boxes evenly with this specific spritesheet. 

After closing that menu, you should be able to notice those very faint lines surrounding the different sprites of our hero. You can see that they cut up our spritesheet just like we want it to. Click `Apply` and close out of the `Sprite Editor`. 

Our `spelunky` spritesheet is ready to go! So let's start with the idle state. Drag the `spelunky_0` icon to the scene view right above the platform. Mine is set right on top of my platform at `X: -6, Y: -3.5, Z: 0`.

Since we want our hero to move, we'll need to add some kind of movement component to him! The way we'll do this in this tutorial is by adding a `Rigidbody2D` component to him. This will allow him to be acted on by physics forces (like gravity). 

We'll do this by making sure we have our `spelunky_0` Game Object selected, and in the `Inspector` view, clicking `Add Component` at the bottom. Then we'll search for `Rigidbody2D` and clicking on the `Rigidbody 2D` component that shows up.
  * You might be tempted to add a regular `Rigidbody` component. Please note that that is the 3D counterpart and we won't be needing it in this tutorial.  

This adds a new component to our Game Object with a lot of different options. We're not going to worry about most of those except for the `Contraints` option. Open that menu up and where it says `Freeze Rotation` we're going to select the `Z` box. This will make sure we can't do any funny rotations because we don't want him flipping when he gets to the edge of the platform (For silliness you can leave this unchecked and see what happens when you move slowly towards the edge of the platform).

Next we'll want to add another component. Click `Add Component` and search for the `Box Collider 2D` component. This will let our hero collide with objects. 
  * You might be tempted to add a regular `Box Collider` component. Please note that that is the 3D counterpart and we won't be needing it in this tutorial.  

You'll notice a green box form around our hero. Any other collider that touches this box will be counted as a collision with our hero. This box seems too big for our hero! So let's make it a bit smaller.

On the `Box Collider 2D` object in the `Inspector` view, click the button by `Edit Collider`. In your `Scene` view, you'll notice that the green box surrounding your hero now has a few little green `Handles` you can grab and move. This will allow you to manually edit the collision box to just the right size. You can also set it in the options. Mine is set to `Offset -> X: 0, Y: 0` and `Size -> X: 0.45, Y: 0.52`. 

Now that our hero can collide with objects, let's hit the `Play`button to see what happens! 

UH OH! Gravity is affecting our hero and he's trying to collide with something but he just FELL THROUGH THE GROUND! It was fast, so stop the game and press play again so you can see it happening. 

The problem here is that even though our hero is trying to collide with things, our platform is only just an image! It has no way to detect if something is colliding with it. We're going to have to beef up our platform if we want our hero to be on top of it. 

Select your `platform_0` Game Object by either clicking on it in the `Hierarchy` or double clicking on it in the `Scene` view. In the `Inspector` view let's click `Add Component` and search for a `Box Collider 2D` component to add. 
  * You might be tempted to add a regular `Box Collider` component. Please note that that is the 3D counterpart and we won't be needing it in this tutorial.  
  
To create a nice effect, where it looks like the hero is standing in the grass of the platform and not just directly on top of it, let's make this box collider a little bit smaller. I set my `Offset -> X: 0, Y: 0` and `Size -> X: 7.1, Y: 0.65`. 

_*NOW*_ let's press `Play` and see what happens.

Our hero stays right where he is supposed to, on top of the platform! And now he's ready to get some movement commands. For this, we're going to have to make a new Script and dive into some C# code. 

