# Setting Up WSL2 with Ubuntu and Jenkins on Windows

This guide walks you through the process of setting up Windows Subsystem for Linux (WSL) with Ubuntu and Jenkins on your Windows machine. This will enable you to run Jenkins within the Ubuntu environment.

## Prerequisites - wsl only

- To install WSL on Windows, you can follow these steps:
### Step 1: Install WSL
1. open MS store and search for wsl and install.
2. Open PowerShell as Administrator.
3. Run the command: `wsl --install`.
   
Ensure that your version of Windows 10/11 is up-to-date: WSL requires Windows 10 version 2004 or later. To check your version of Windows, go to Settings > System > About and look for the "Version" number.

Install a Linux distribution: Once the WSL feature is enabled, you can install a Linux distribution from the Microsoft Store or from the command line. To install a distribution from the Store, open the Store app, search for your desired distribution (e.g. Ubuntu), and click "Get". To install a distribution from the command line, open PowerShell or Command Prompt and run the following command: 

wsl --install -d <distro>, where <distro> is the name of the distribution you want to install (e.g. Ubuntu).
3. wsl --install -d Ubuntu-22.04  #this will install ubuntu on windows 

Set up your Linux distribution: Once the distribution is installed, open it from the Start menu or by running the wsl command. The first time you run the distribution, you will be prompted to create a user account and set a password.

setup systemd on wsl once got the wsl shell prompt check /etc/wsl.conf  for [boot] systemd=true
4. $ wsl --shutdown Ubuntu  # shutdown wsl
5. $ systemctl list-unit-files --type=service   # Start wsl again &  verify systemd is ready to work with command

That's it! You should now have WSL installed and running on your Windows machine, allowing you to use Linux command-line tools and applications.
### Step 2: Install Ubuntu on WSL

1. Open Microsoft Store.
3. Launch the installed Ubuntu app and follow the prompts to set up your Ubuntu username and password.
### Step 3: Update and Install Dependencies

1. Launch the Ubuntu terminal.
2. Update the package repository information: `sudo apt update`.
### Step 4: Install Jenkins on Ubuntu
2. $ curl -fsSL https://pkg.jenkins.io/debian-stable/jenkins.io-2023.key | sudo tee /usr/share/keyrings/jenkins-keyring.asc > /dev/null
4. $ apt update # update ubunut repo
5. $ apt install jenkins # install jenkins

### Step 5: Access Jenkins Web Interface

1. Open a web browser on your Windows machine.
2. Navigate to `http://localhost:8080`.

### Step 6: Install Plugins and Set Up Jobs
1. Once Jenkins is set up, install the necessary plugins for your projects.
2. Create Jenkins jobs to build, test, and deploy your projects as needed.
3. Define build steps using shell commands within your Ubuntu WSL environment.

### Step 7: Integration with Windows

2. Access Ubuntu's file system through the path \\wsl$\Ubuntu-22.04 in Windows File Explorer.
## Troubleshooting

- If you encounter permission issues, ensure you're running commands with appropriate privileges (using `sudo`).
- Check the official documentation for WSL, Ubuntu, and Jenkins for troubleshooting specific issues.
## Conclusion

Congratulations! You've successfully set up WSL with Ubuntu and Jenkins. You can now utilize Jenkins for continuous integration and deployment within the Ubuntu environment.

Remember to refer to the official documentation for the most up-to-date instructions and troubleshooting tips.

Happy coding!
