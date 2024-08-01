# Brute-Force-Password-Hash-Cracker
This is an educational tool that will help you understand how password-crackers work  <br>
This tool implements the Power Set algorithm to get all possible combinations of passwords, making it the most accurate password cracker out there.  <br>


## Notes
1. I do not endorse illegal activity of any kind. I also do not wish to enable anyone to perform illegal activity.
2. This tool was designed strictly for educational purposes.
3. You assume ALL liability when using this tool for illegal activity, or when converting this tool into a cyber-weapon of ANY kind.
4. It is ILLEGAL to attempt to crack passwords that you do not own, as well as systems that you do not own.
5. Computers have finite memory to work with, and this tool (because of the use-case and mathematical algorithm it implements) uses lots of RAM. Please keep an eye on your PCs memory usage and keep the password length within a reasonable threshold for your PC (Don't go over 5 chars, unless your PCs from NASA)


## The app's intended purpose:
This tool was designed with the aim of showing people how their passwords could be reverse-engineered by hackers - so that they are better able to defend themselves by creating more complex passwords.
<br>
The entropy of a password increases with the size of the password and, in that vein, using more random characters and symbols creates a stronger password because it requires more combinations and iterations to crack.
<br>
This sounds like common-sense, because "1234" (4 characters) is going to be weaker that "12345678" (8 characters), but this also applies to the contents of the password itself. 
<br>
Due to how some other password crackers are written: "1'[$" (4 characters) is more secure than its equivalent "1234" (4 characters), etc. (Note: For this app, both passwords are equally weak)
<br>
At some point, a password can become almost impossible to crack immediately ("immediately" is the keyword here) using a tool like this, because of current computing constraints,  <br>
Hackers would then require a "slower" approach, which sacrifices speed for memory/resources efficiency, <br>
Meaning that your password will STILL be vulnerable to reverse-engineering over a longer period of time, or when computers become more powerful (every 18 months - [Moore's Law](https://www.intel.com/content/www/us/en/newsroom/resources/moores-law.html)). <br>


### What you will come to understand from using this tool is:
Having a long password (12 chars, for example) isn't Secure enough - if you're only using the same 5 characters to create that password. <br>
For real-world passwords, you absolutely should use longer passwords with more random combinations of characters and symbols, to make it more difficult to reverse-engineer. <br>
You should also avoid using the same passwords for different sites/systems. <br>
 <br>
 <br>
## Overview of How the App Works:
When started, the app will specify some parameters for you to work within. <br>
When you input a random "password", the app will generate a hash for the "password", and then try to reverse-engineer that hash (Which should be impossible, because of how hashing works) 
<br>
Note: For smaller passwords (1~3 characters), because of the speedy reply, it's easy to believe that the app is just telling you what your password was without any calculation needed, but a quick read through the code should dispell any of those doubts
 <br>
 <br>
## Some Additional Info on Hackers and Common Tactics:
Hackers/"Malicious Actors"/"Threat actors" may sometimes manage to compromise a database of stored password hashes <br>
(This isn't uncommon - since most passwords aren't stored in "plain English", but are stored as hashes [Which are meant to be impossible to reverse-engineer - because hashing is a one-way function]) <br>
The attacker would then use a tool like this, a rainbow-table or some other hybrid-tool, to attempt to reverse-engineer that stolen/compromised hash. <br>
They could also use Cyber Weapons similar this, to automatically send hundreds-of-thousands of login-attempts to a server (With your stolen username), to "guess" the password and gain access. <br>
This is why "Lockout counts" (Although annoying to us as users) are so important! They effectively prevent the hacker from logging into your account, by locking your account after a few failed login attempts <br>
But these could also be exploited to cause Denial Of Service (DOS) attacks, to prevent you (The user) from using a specific service.<br>