# BlackJack
BlackJack 21 game in the shell made in C#

## Gamme rules
The main objective of Blackjack 21 is to obtain a hand of cards whose total value is 21 or as close to that number as possible without going over. <br>
Numbered cards (2 to 10) are worth their face value. Face cards (king, queen, and jack) are each worth 10 points. The ace can be worth 1 or 11 points, depending on what is better for your hand. <br>
The player receives two cards face-up, while the dealer (representing the casino) receives one card face-up and one face-down. <br>
The player adds the value of their two cards to see if they have a total of 21 (an ace and a 10-value card), which is called "Blackjack." If they do not have Blackjack, they can choose to request more cards (hit) to get closer to 21 or keep the cards they have (stand). <br>
If the player has 21 with their two initial cards (a Blackjack), they win automatically unless the dealer also has a Blackjack. In that case, the game ends in a tie (push). If the player decides to request more cards and the total value of their cards exceeds 21, they lose automatically, and it is called a "bust." <br>
Once the player has made their decisions, the dealer reveals their face-down card and continues to draw cards until they have at least 17 points. <br>
After the dealer has finished their turn, the player's cards are compared to the dealer's cards. The one who is closer to 21 (without going over) wins. If the dealer goes over 21 and the player has not, the player wins. <br>
If there is a tie at 21 between the dealer and the player, but the dealer achieved it with a lower number of cards, the dealer wins. This is known as the "dealer's advantage." <br>