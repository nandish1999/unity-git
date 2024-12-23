
//--------------------------------(Whenever hit play button timer again starts from 0 second (and old values disapper)) ---------------------
//(doesn't Append the time but resets it)

using UnityEngine;
using System.IO;

public class CameraForwardVectorTracker : MonoBehaviour
{
    public string fileName = "forward_vector_data.csv";
    private StreamWriter writer;

    private void Start()
    {
        // Create a new StreamWriter to write the CSV file
        writer = new StreamWriter(fileName, true);
        writer.WriteLine("Time,Forward Vector X,Forward Vector Y,Forward Vector Z"); // Write headers
    }

    private void Update()
    {
        // Get the forward vector of the camera (or player)
        Vector3 forwardVector = transform.forward;

        // Get the current in-game time (Time.time)
        float currentTime = Time.time;

        // Log the forward vector and time to the console with full precision
        Debug.Log("Time: " + currentTime.ToString("F7") + " - Forward Vector: (" +
                  forwardVector.x.ToString("F7") + ", " +
                  forwardVector.y.ToString("F7") + ", " +
                  forwardVector.z.ToString("F7") + ")");

        // Log the forward vector and time to the CSV file
        writer.WriteLine($"{currentTime},{forwardVector.x},{forwardVector.y},{forwardVector.z}");
    }

    private void OnApplicationQuit()
    {
        // Close the StreamWriter when the application is quitting
        writer.Close();
    }
}



//---------------------------(Appending the time instead of resetting it)--------------------------


// using UnityEngine;
// using System.IO;

// public class CameraForwardVectorTracker : MonoBehaviour
// {
//     public string fileName = "forward_vector_data.csv";
//     private StreamWriter writer;
//     private float accumulatedTime = 0f;  // Tracks total time across multiple Play sessions

//     private void Start()
//     {
//         // Create a new StreamWriter to write the CSV file
//         writer = new StreamWriter(fileName, true);
//         if (new FileInfo(fileName).Length == 0) // Check if the file is empty
//         {
//             writer.WriteLine("Time,Forward Vector X,Forward Vector Y,Forward Vector Z"); // Write headers if the file is empty
//         }
//         else
//         {
//             // Read the last time recorded from the file (if it exists)
//             string[] lines = File.ReadAllLines(fileName);
//             string lastLine = lines[lines.Length - 1];
//             string[] columns = lastLine.Split(',');
//             accumulatedTime = float.Parse(columns[0]);  // Get the last time from the CSV file
//         }
//     }

//     private void Update()
//     {
//         // Increment the accumulated time
//         accumulatedTime += Time.deltaTime;

//         // Get the forward vector of the camera (or player)
//         Vector3 forwardVector = transform.forward;

//         // Log the forward vector and time to the console with full precision
//         Debug.Log("Time: " + accumulatedTime.ToString("F7") + " - Forward Vector: (" +
//                   forwardVector.x.ToString("F7") + ", " +
//                   forwardVector.y.ToString("F7") + ", " +
//                   forwardVector.z.ToString("F7") + ")");

//         // Log the forward vector and time to the CSV file
//         writer.WriteLine($"{accumulatedTime},{forwardVector.x},{forwardVector.y},{forwardVector.z}");
//     }

//     private void OnApplicationQuit()
//     {
//         // Close the StreamWriter when the application is quitting
//         writer.Close();
//     }
// }

