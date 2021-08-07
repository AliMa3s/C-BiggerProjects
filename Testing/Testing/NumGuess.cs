using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing {
    /// <summary>
    /// Ask the user to guess num between certain range
    /// </summary>
    class NumGuess {
        #region public properties
        /// <summary>
        /// The largest number we as the user to guess, between 0 and this number
        /// </summary>
        public int MaximumNumber { get; set; }
        /// <summary>
        /// The current number of guess the computer had
        /// </summary>
        public int NumberOfGuesses { get; private set; } = 0;
        /// <summary>
        /// The current known number the user is thinking
        /// </summary>
        public int CurrentGuessMinimum{ get; private set; } = 0;
        /// <summary>
        /// The current known maximum number the user is thinking of
        /// </summary>
        public int CurrentGuessMaximum { get; private set; }
        #endregion

        #region ctor
        /// <summary>
        /// Default constructor
        /// </summary>
        public NumGuess() {
            // set default max num
            this.MaximumNumber = 100;
        }
        #endregion

        public void InformUser() {
            Console.WriteLine($"Give a number between 0 and {this.MaximumNumber}");
            Console.ReadKey();
        }
        /// <summary>
        /// Ask user series of questions
        /// </summary>
        public void DiscoverNumber() {

            this.NumberOfGuesses = 0;
            this.CurrentGuessMinimum = 0;

            this.CurrentGuessMaximum = this.MaximumNumber / 2;

            while (this.CurrentGuessMinimum != this.CurrentGuessMaximum) {
                this.NumberOfGuesses++;

                Console.WriteLine($"Is your number between {this.CurrentGuessMinimum} and {CurrentGuessMaximum}");

                string response = Console.ReadLine();

                if(response?.ToLower().FirstOrDefault() == 'y') {
                    this.MaximumNumber = this.CurrentGuessMaximum;

                    this.CurrentGuessMaximum = this.CurrentGuessMaximum - (this.CurrentGuessMaximum - this.CurrentGuessMinimum) / 2;
                } else {
                    this.CurrentGuessMinimum = this.CurrentGuessMaximum + 1;

                    int remainingDifference = this.MaximumNumber - this.CurrentGuessMaximum;

                    this.CurrentGuessMaximum += (int)Math.Ceiling(remainingDifference / 2f);
                }

                if (this.CurrentGuessMinimum +1 == this.MaximumNumber) {
                    this.NumberOfGuesses++;

                    Console.WriteLine($"Is your number {this.CurrentGuessMinimum}?");

                    if (response?.ToLower().FirstOrDefault() == 'y') {
                        break;
                    } else {
                        this.CurrentGuessMinimum = this.MaximumNumber;
                        break;
                    }

                }
            }
        }

        /// <summary>
        /// Announce the number the user was thinking of 
        /// </summary>
        public void AnnounceResult() {
            Console.WriteLine($"** Your number is {this.CurrentGuessMinimum} **");
            Console.WriteLine($"** Gussed in {this.NumberOfGuesses} guesses**");
            Console.ReadKey();


        }
    }
}
