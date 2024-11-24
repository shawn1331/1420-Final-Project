# 1420-Final-Project
Hangman
Questions:
    1. Should I have both players trying to guess the same word or should I have them each have the same word and pit them against each other to see who can guess it first and who has the most points?

    2. If they are guessing the same word it should probably be turn based.

    3. If they are guessing the same word should I show the same list of missed guesses to both players or should I have each of them have their own list of missed guesses that the other player cannot see so they cannot use their opponents missed guesses to aid them in guessing correctly?

    4.





/* Parent container styles */
.game-container {
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
    gap: 20px; /* Space between players */
    padding: 10px;
}

/* Individual player sections */
.player-section {
    flex: 1; /* Equal width for both sections */
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    background-color: #f9f9f9;
}

/* Styling for specific players */
.player-me {
    background-color: #e6f7ff; /* Light blue background for PlayerMe */
}

.player-other {
    background-color: #ffe6e6; /* Light red background for PlayerOther */
}

/* Responsive adjustments */
@media (max-width: 768px) {
    .game-container {
        flex-direction: column; /* Stack players vertically on small screens */
    }
}


/* Style the game creation section */
.game-creation {
    margin-bottom: 20px;
    padding: 15px;
    background-color: #f4f4f4;
    border: 1px solid #ddd;
    border-radius: 8px;
}

