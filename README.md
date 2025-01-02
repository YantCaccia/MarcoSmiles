# MarcoSmilesVR

MarcoSmilesVR is an innovative project that leverages Artificial Intelligence (AI) and Extended Reality (XR) to enable musical expression through gesture recognition. The system has been developed to provide an inclusive, accessible, and immersive interface for people with motor disabilities, using advanced hand-tracking techniques and reinforcement learning. This repository hosts the two main components of the project: **MarcoSmilesQuest (Client)** and **MarcoSmilesServer (Server)**.

---

## System Architecture

The architecture of MarcoSmilesVR follows a modular **Client-Server** approach, where:
- The **Client** handles the user interface and collects gesture data via XR devices like Meta Quest 3.
- The **Server** processes the data, trains AI models, and returns results for real-time musical generation.

### Technologies Used

![Unity](https://img.shields.io/badge/Unity-2022.3-black?logo=unity) ![Meta Quest SDK](https://img.shields.io/badge/Meta%20Quest%20SDK-71-blue?logo=oculus) ![Python](https://img.shields.io/badge/Python-3.9-yellow?logo=python&logoColor=white) ![Flask](https://img.shields.io/badge/Flask-2.x-red?logo=flask) ![Gym](https://img.shields.io/badge/Gym-0.26-green?logo=openaigym) ![PyTorch](https://img.shields.io/badge/PyTorch-1.13-red?logo=PyTorch)

- **Client**:
  - Unity Engine for XR platform development.
  - Meta SDK and Unity XR SDK for hand-tracking and color passthrough support.
- **Server**:
  - Python for backend implementation.
  - Flask for HTTP request management.
  - PyTorch for training and inference of the Deep Learning model.
  - Deep Q-Learning as the AI paradigm for gesture recognition.

---

## Client: MarcoSmilesQuest

### Description

MarcoSmilesQuest is the client module designed to run on Meta Quest (2, 3, 3S) devices. It uses hand-tracking to capture hand poses and send them to the server for pose recognition. The response is then used to generate musical notes, allowing users to play virtual instruments in real time.

### Key Features

- **Note List selection**: Allows the configuration of the notes range the user wants to play.
- **Training Mode**: Records hand pose data and sends it to the Server for model training.
- **Performance Mode**: Enables users to play virtual musical instruments in real time.

### How to Start

1. **Import the Project into Unity Hub**:
   - Open Unity Hub.
   - Click the **Add** button.
   - Navigate to the `MarcoSmilesQuest` folder and select it.
2. **Configure the build settings for Meta Quest**:
   - Go to **File > Build Settings**.
   - Select **Android** as the platform and click **Switch Platform**.
3. **Configure the server IP address**:
    - In the Unity Editor Hierachy, select the `ServerCommunicator` object.
    - In the `Server Gateway` component, set the `Server URL` field to http://\*serveripaddress\*:5005.
4. **Deploy the application to the Meta Quest device**:
   - Connect the device via USB.
   - Click **File -> Build and Run** to deploy the application.

---

## Server: MarcoSmilesServer

### Description

MarcoSmilesServer is the backend module responsible for processing gesture data. It implements a **Deep Reinforcement Learning** model for hand pose recognition and pose-to-note mapping.

### Main Endpoints

- **`/new-model`**: Initializes a new AI model based on the selected note range.
- **`/hand-data`**: Receives hand pose data and uses it for training.
- **`/hand-data-play-mode`**: Returns the musical note associated with a specific pose.
- **`/save-model`**: Saves the trained model for future sessions.

### How to Start

1. Navigate to the `MarcoSmilesServer` directory.
2. Install dependencies with the command:
   ```bash
   pip install -r requirements.txt
    ```
3.	Start the server with:
    ```bash
    python app.py
    ```

## Usage Example
### Typical Workflow

1. **Select the Note Range**  
   Open the app and select the desired note range using the client device controllers.  
   - First, select the **starting note** of the range.  
   - Then, select the **ending note** of the range.
   - All the notes between the starting and ending notes will be included in the range.

    Note that at this time you cannot select notes one by one. You can only select the starting and ending notes of the range.

2. **Start Training Mode**  
   Activate Training Mode by selecting **Training** and begin training the system.  
   - Monitor the accuracy indicator displayed in the **bottom right corner** of the right window.  
   - Continue the training process until the accuracy reaches **at least 55%**.

3. **End Training Mode**  
   Exit Training Mode by clicking **End Training** on the interface.

4. **Activate Performance Mode**  
   Start Performance Mode by selecting **Play** from the main menu. Use your hand gestures to play virtual musical instruments in real time.

## Contributors
Project developed by Antonio Cacciapuoti as part of his Master’s Thesis at the University of Salerno.