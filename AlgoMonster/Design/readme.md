Design style questions

Meta + Netflix 

Prep Strategy

Taking this example
https://leetcode.com/problems/simple-bank-system

Issues
	- lenghtly description can consume lot of time

Fix 
	- scan for key APIs

🧠 Step 1: Don’t Read It Like a Story

These design questions are long because:

	They describe rules

	They describe constraints

	They simulate a real-world system

But under pressure, you should scan for only:

	What are the operations?

	What is the input?

	What is the expected output?

	What constraints matter?

For Simple Bank System, the real core is:

You need to implement:

	transfer(account1, account2, money)

	deposit(account, money)

	withdraw(account, money)

That’s it.

	Everything else is flavor text.


1️. Extract the API first

	Before coding anything:

“Okay, we have 3 public methods:

	transfer

	deposit

	withdraw”

Just list them.

	This gives structure immediately.


2️. Decide the Core Data Structure

Ask:

What is the main data model?

	For Bank System:

	We have accounts

	Each has a balance

	Accounts are 1-indexed

So you immediately think:

	Array?

	Dictionary?

Since account numbers are fixed and numeric → array is perfect.

That’s 80% of the problem


3️. Clarify Edge Conditions (Meta loves this)

Ask aloud:

	What if account number is invalid?

	What if insufficient balance?

	What if transfer to self?

	Are balances long?

Meta likes when you proactively clarify.


4️. Keep It Boring

Do NOT overengineer.

	No fancy classes.
	No account objects.
	No inheritance.

Meta prefers:

	Simple.
	Readable.
	Predictable.


5️. Code in Small Chunks

Implement:

	deposit first

	withdraw second

	transfer last

Because transfer reuses withdraw logic mentally.



For the next 2 weeks, 

Pick 4 total problems:

	LRU Cache

	Design Twitter

	Simple Bank System

	RandomizedSet



Something along these lines --

Weekly Template

Mon – Trees
Tue – Matrix/Grid
Wed – Mock
Thu – Trees (harder variant)
Fri – Design (45 min only)
Sat – Mock
Sun – Light review / mistake journal

That’s it.

Design = once a week, short session.




