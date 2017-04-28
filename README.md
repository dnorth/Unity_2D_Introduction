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


Open the `Scripts` folder in your `Project` view and right click. Navigate to `Create -> C# Script`. This will create a new script that we will use to control our character. Let's name it `MovementController` and then double click on it to open it. 

The script will open up Visual Studio if you have it installed, or MonoDevelop by default. When we inspect the script we'll notice that a class already exists and two pre-existing functions: `void Start()` and `void Update()`.

`void Start()` is a function that is called only once when the object is instantiated (or... started) and `void Update()` is called once per frame.

```C#
    //1
    public float speedFactor = 5.0f;

    //2
    private Rigidbody2D rigidBody;

    //3
    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update () {
        //4
        float walkingInput = Input.GetAxisRaw("Horizontal");

        //5
        rigidBody.velocity = new Vector2(walkingInput * speedFactor, rigidBody.velocity.y);
    }
```
This snippet shows the code that we will be adding for this section and the comments show corresponding numbers that we'll use to break the block down. 

Here we've: 
 1. Defined a `float` (decimal number) that we'll use as a factor to determine how fast our hero can go. It is `public` so that the Unity editor can access it and so it can be changed in the GUI. We'll touch back on this later. 
 2. Defined a `private` variable to access our `Rigidbody2D` component and called it `rigidBody`. It's private so that other classes can't just go messing with its properties.
 3. Initialized the `rigidBody` variable once our scene `Start()`s up. We will get the `Rigidbody2D` component of the object this script is attached to. (This means that you will get an error if you put this on something that does _not_ have a `Rigidbody2D` component) 
 4. Defined a local `float` called `walkingInput` that will give us the `Horizontal` axis that is inputted by the user. This is a pre-defined Unity axis that works with the left and right arrows, the `A` and `D` keys and joysticks. (For more information please reference the [Unity Scripting API: Input](https://docs.unity3d.com/ScriptReference/Input.html))
    * Note that we are calling `Input.GetAxisRaw` instead of `Input.GetAxis`. `Input.GetAxis` would give us a gradual incline the more we held the button down, to a max of `1`. `Input.GetAxisRaw` gives us either a `0` or a `1`, so our hero can run at full speed from the beginning and not have to ramp up to it.
 5. Set the velocity of our `Rigidbody2D` component to be a new [Vector2](https://docs.unity3d.com/ScriptReference/Vector2.html) where the X (or Horizontal) velocity is equal to our `walkingInput` multiplied by our `speedFactor` and our Y (or vertical) velocity is equal to whatever the velocity of the `Rigidbody2D` component is (`rigidBody.velocity.y`)
    * There are a few ways to move this character, and since we want the character to move instantly without any ramp-up, we have chosen to update his velocity directly. Later we'll show a different example of movement by adding force to the character, instead of changing the velocity directly.
   
Now that we've scripted the user being able to move horizontally, let's go back to the Unity Editor and use our new script! (Make sure to save before moving though) 

In the `Project` view, click on your `MovementController` script and drag it to the `spelunky_0` Game Object in the `Hierarchy` view.     * Alternatively, if you select the `spelunky_0` Game Object beforehand, then you can drag your `MovementController` script to the `Inspector` view

If everything is correct up until this point (meaning you don't have any errors indicated by red text in the bottom left of the editor) then you should be able to select your `spelunky_0` Game Object and see the new `Movement Controller (Script)` component in your inspector. 
  * Take note of the `Speed Factor` parameter that is editable in the editor. It shows the default `5` but can be changed to any number to make your hero move faster or slower as you please!

Let's click `Play` again and see if our hero can move now! 

HUZZAH! He moves! But play around with it for a little bit and you'll notice a few things... 

1. He only faces one direction, so if you move him backwards he doesn't flip around
2. He stands still while moving, he's moving but not walking!
3. You can't jump (that's expected since we only got the horizontal input)

To fix number `1`, let's hop back into the movement script. We can have him flip around by editing the transform of the sprite. We will apply a negative scale to the X (horizontal) axis and it will flip the character for us. 

```C#
    public float speedFactor = 5.0f;
    private Rigidbody2D rigidBody;

    //1
    private bool facingRight = true;

    void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update () {
        float walkingInput = Input.GetAxisRaw("Horizontal");
        rigidBody.velocity = new Vector2(walkingInput * speedFactor, rigidBody.velocity.y);

        //2
        if ( walkingInput > 0 && !facingRight)
        {
            FlipFacing();
        }
        else if ( walkingInput < 0 && facingRight)
        {
            FlipFacing();
        }
    }

    //3
    void FlipFacing()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
```

Here's our new and improved `MovementController` class. We've: 

1. Added a new `bool`ean (`true` or `false`) variable called `facingRight` that we will intialize with the value `true` since our hero faces right at the start. 
2. Added a few conditions:
    * If we pressed the key to go to the right (`walkingInput > 0`) AND if we're not facing right already (`!facingRight`) then we will call a method called `FlipFacing()` which we'll define later
    * If we pressed the key to go to the left (`walkingInput < 0`) AND if we're facing right (`facingRight`) then we will call that same `FlipFacing()` method which will flip our hero's sprite
3. Defined that `FlipFacing()` method. This is what is being called. In this method we are doing two things:
    * Setting `facingRight` to what it was not before `!facingRight` (if `true` it's now `false`, visa versa) 
    * Setting the `localScale` of the `transform` we are attached to to be a new `Vector2` where the `X (Horizontal)` value is the negative version of what it was before `-transform.localScale.x` and the `Y (Vertical)` value to the same as it was before `transform.localScale.y`

Now we can go back to our Unity Editor and hit `Play` since our script is already attached to our hero. 

If all goes well, our hero should now flip back and forth when hitting the left and right keys. Now we need to figure out how to get him to actually _look_ like he's walking!


