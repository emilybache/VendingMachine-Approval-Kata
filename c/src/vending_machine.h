#ifndef VENDINGMACHINE_VENDING_MACHINE_H
#define VENDINGMACHINE_VENDING_MACHINE_H

// number of characters that fit onto the display
#define DISPLAY_LENGTH 20
// maximum number of coins that fit in the machine
#define COIN_CAPACITY 100

struct vending_machine {
    char display[DISPLAY_LENGTH];
    long balance;
    int coins[COIN_CAPACITY];
    int coin_count;
};

struct vending_machine* vending_machine_create();
void insert_coin(struct vending_machine*, int);

#endif //VENDINGMACHINE_VENDING_MACHINE_H
