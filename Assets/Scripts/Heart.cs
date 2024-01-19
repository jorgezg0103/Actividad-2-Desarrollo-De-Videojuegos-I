using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{
    protected override void performAction() {
        int lives = GameController.lives;
        if(lives < 3) {
            GameController.changePlayerLives(GameController.lives + 1);
        }
    }
}
