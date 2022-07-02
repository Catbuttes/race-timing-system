
# Race Timing System
_Set by: **Matt**_

Create a race timing system, that tracks every lap time set by a
driver, this should include their name, the tyre they used (Hard,
Medium, Soft, Intermediate, Wet) and their lap time.
Then, create a leaderboard system, that searches for the best
time set by every driver and orders them from fastest to slowest.
This should be updated automatically, every time a new time is
set. Recommended languages are Java or C#.

1. Create a window with 3 fields and a button. The fields will
be for the name, tyre and lap time. The button will be to submit
the information entered in the fields. When the submit button is
pressed, the information in the fields should be printed to the
console.

2. Create a table with the same headings as the fields in the
first task. Program your submit button to add the entries in the
field to the table you just created.

3. Create a second view for the window. You should be able to
change between the two views with two buttons in the window.
These could be named “Times” and “Leaderboard”. On your
leaderboard view, there should only be a table. This table should
be automatically updated each time a new time is submitted. It
should contain the name and best lap time of every name that has
submitted a lap.

4. Create a method of saving laps that have been submitted, this
could either be through a database or just a simple file. When
the program loads it should read the database/file and update
both the leaderboard and the timings list.

5. Add functionality to wipe all the saved times.

6. Add functionality to delete a single lap time.
