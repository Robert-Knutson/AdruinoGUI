# AdruinoGUI
Welcome to the Perturbation Treadmill Control Program.

The goal of thsi project is to create a Graphical User Interface that allows data to be communicated from and Arduino to a computer. The user interface is intuitive and easu to use by people will little programming background.


The application has three main components.
1.	Graphically display data received from the Arduino on the received data page.
2.	Create new perturbation profiles. These are saved as CSV files and can be manually entered into the Arduino code.
3.	Create new profiles and run them. The previous way the treadmill was controlled was that new profiles were written in Matlab, and then the resulting motor speed and timing arrays were manually pasted into the Arduino source code. While this was simple and effective, it made modifying profiles on the fly difficult. With this new software, the computer dictates the motor speeds in real-time, telling the motors how fast to go and when. This was accomplished by creating asynchronous serial communication subroutines, allowing 2-way communication (read and write from the serial port) simultaneously without the program erroring out and data being lost. 

Directions for use.
1.	Connect the Arduino to the computer via the USB cable. If you do not see anything on the COM Port dropdown, restart the software.
2.	Make sure the Baud Rate is correct. 115200 is the default I've been using, but you can change it to whatever you want. This must match the value in the Arduino Serial.begin() code.
3.	Click connect. The Arduino is now connected, and you can now begin receiving data and executing new profiles. 

![StandAloneTreadmillSoftware](https://user-images.githubusercontent.com/63023502/229213606-667cb86f-1d85-430a-a004-c527782f1aef.JPG)

The run new profile tab is the one you want to use if you want the computer to be able to dictate the motor speeds in real-time. First input the desired speeds and times on the Profile Input table. Points can be added by clicking the blank boxes at the bottom of the table as needed. Once the desired points have been added, click the interpolate button. This interpolates the lines between the points at a rate of 25 points per second. The output of the interpolation is shown in the Interpolated Belt Speeds table. Next, the software converts this into a PWM value that the Arduino can use to dictate the motor speed. After clicking the interpolate button, the seconds two tables (Interpolated Belt Speeds and Motor PWM Values) are mostly for data verification and to make sure everything looks right (you shouldn't need to edit the data in these tables) If everything looks good click the Begin Profile button. This will begin sending the motor speeds to the Arduino at the times dictated by the millisecond timing values in the motor PWM table. Go to the Recieved Data tab to see the result. The Arduino should echo the motor speed it received and the time that it received it. The output should look something like this.

![StandAloneTreadmillSoftware](https://user-images.githubusercontent.com/63023502/229215953-5afb6f44-711d-4b29-a07c-51407bae511b.JPG)
