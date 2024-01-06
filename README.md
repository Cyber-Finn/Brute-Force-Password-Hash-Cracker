# EducationalTool_BruteForce_PasswordCracker_PowerSet
This is an educational tool that will help you understand how password-crackers work

* Note: For easier reading, please navigate to the actual "ReadMe.md" file, and open it in "Code" view.


## Notes
I do not endorse illegal activity of any kind. I also do not wish to enable anyone to perform illegal activity. 
This tool is strictly for educational purposes. 
You assume ALL liability when using this tool for illegal activity, or when converting this tool into a cyber-weapon of ANY kind.

It is ILLEGAL to attempt to crack passwords that you do not own, as well as systems that you do not own.

## Basic Summary of the app and it's intended purpose:
This app is not intended to be used as a real-world brute-force password cracker, or "hacking tool" of any kind!
It's merely an educational tool, to help people understand that the entropy of a password increases with the size of the password, and how their passwords could be reverse-engineered - so that they are better able to defend themselves.
In that vein, more characters and symbols create a stronger password - which requires more combinations and iterations to crack.
At some point, the password becomes almost impossible to crack using a tool like this (Because of current resource constraints), 
And it'd then require a "slower" approach, which sacrifices speed for memory/resources efficiency,
meaning that your password may STILL be vulnerable (Even if this tool can't crack it) over a longer period of time.
              
This application may also benefit anyone looking for an example of: How to implement the mathematical "Power Set" algorithm - to get ALL possible combinations of a given series of characters/numbers/symbols, although it does slightly differ because of the use-case.
This also means that the tool is able to - theoretically - crack ANY "password" with 100% accuracy, as it gets ALL possible combinations, 
but the tool is bound by modern computing resource-constraints, 
because the Power Set becomes exponentially massive as the length of the "password" increases - and computers have only finite memory to use.

The app can definitely be improved and made to be more efficient, 
but it is PURPOSELY designed to be user-UNfriendly and developer-UNfriendly to increase the difficulty of turning it into a cyber-weapon.
I also wrote this over a weekend, and will likely improve it at some point in the future - but may not release the improved version to public, for obvious reasons.

** What you will come to understand from using this tool is:
Having a long password (12 chars, for example) isn't enough Security, if you're only using the same 5 characters to create that password.
(You can test this by changing "passLength" to 12, and using 5 unique characters in the "chars" array, then inputting a random 12-character password in the Console, and seeing how long it takes to reverse-engineer)
You absolutely need to use longer passwords with more combinations of characters and symbols.
You should also avoid using the same passwords for different sites/systems.


## How the app basically works:
When started, the app will specify some parameters for you to work within.
When you input a random "password", the app will generate a hash for the "password", and then try to reverse-engineer that hash (Which should be impossible, because of how hashing works)


## Some Additional Info:
Hackers/"Malicious Actors"/"Threat actors" may sometimes manage to compromise a database of stored password hashes
(This isn't uncommon - since most passwords aren't stored in "plain English", but rather stored as hashes [Which are meant to be impossible to reverse-engineer - because hashing is a one-way function])
The attacker would then use a tool like this, a rainbow-table or some other hybrid-tool, to attempt to reverse engineer that hash.
They could also use cyber-weapons similar this, to automatically send hundreds-of-thousands of login-attempts to a server (With your username), to "guess" the password and gain access.
This is why "Lockout counts" (Although annoying) are so important! They would effectively prevent the hacker from logging into your account, by locking your account after a few failed login attempts
But these could also be exploited to cause Denial Of Service (DOS) attacks, to prevent you (The user) from using a specific service.

