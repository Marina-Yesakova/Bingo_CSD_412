# Bingo_CSD_412

Buzzword Bingo
Group B - John, Marina, Kyle
10/19/2018
Overview
The idea is to make a very simple Buzzword Bingo board to begin with and to continually add new features as we build out the application. Basically we are going to follow an Agile approach to this and build something that barely works to begin with and slowly add features as we get better with using ASP.Net Core, MVC, and Azure services
Beginning with the Basics
I want to take an approach of ‘lets build as little as possible to get a working product’. Think Agile.
Web App
Use Azure with a student account to create a publicly available application. I think Dave said it was pretty easy to create a web app and attach a SQL database. I’m hoping he goes over it in class soon.. I’m still pretty lost on how to connect a web app to a database and where to perform SQL queries to get data or populate the database.
Views
	Two views to start with..
Buzzword Bingo board
Maybe update the Bingo board after a page refresh to start with
Move to creating a button later
See all words currently in the database
Later on be able to write to the database or update words
	As for styling/CSS I’m hoping to make use of Bootstrap to make the project look somewhat professional without much effort. 
Controllers
	Not much going on here except to pass data from the database/model to the view. In future features we will likely add more here.
Models
	AKA See database entities
Database
Entities
Name - “Words”
Columns:
Name - coalesce on to prevent duplicate words
Description/Definition - Allow users to give a definition of the word
Created by
Created on
Updated by [future release]
Updated on [future release]
Name - “Users” [this isn’t necessary in the beginning and can be ignored for now]
Columns:
First name
Last name
Alias/Username [future future release]
Password [future future release]
User Id
Name - “Game sessions” [I really doubt we’d get this far.. But this would be if we could implement a “game room” or something]
User Interaction
Later on in the project users can add new words to the database, update existing word definitions, or query the database for specific words. Not needed for the beginning


Review
Again, to get us off the ground I think if we manage the following, we would be in pretty good shape:
Stand up a web app
Stand up a database
Connect the web app to the database
Query database in order to populate a model for the web app
Create views
One that builds the bingo board
Allow users to check off words that they hear
Performs validation to see if the user has a ‘Bingo’
Provide feedback that the user has won
Another that shows a list of entries in the database
Each view would share a common nav bar that links to the other

If we complete that quickly enough, then we can start looking into giving users the ability to add to the database or update entries in the database or user authentication or anything else. 

Other thoughts
Dave mentioned he wanted us to have an API that other web services could consume. He made this sound easy… Not sure about that or what we could offer. Thoughts?

He also mentioned he wanted our app to reach out and consume another public API. We could possibly query dictionary.com to retrieve a definition for the words in our “Words” database

API we could create:
We will have same url for both API clients and browsers. When browsers will send their requests they will add http header “accept-encoding: text/html”. The service will return them html page. When API clients will send their requests they will add header “accept-encoding: application/json”. Service will return them json with bingo board id and words.

