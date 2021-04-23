
#include <stdlib.h>
#include <string.h>
#include <stdio.h>
#include "vending_machine.h"

struct vending_machine* vending_machine_create() {
    struct vending_machine* machine = malloc(sizeof(*machine));
    strncpy(machine->display, "INSERT COIN", sizeof(machine->display) - 1);
    machine->balance = 0;
    machine->coin_count = 0;
    return machine;
}

void presentBalance(const long balance, char *price) {
    char dollars[DISPLAY_LENGTH - 5];
    char cents[3];
    strcpy(price, "$");
    sprintf(dollars, "%ld", balance / 100);
    strcat(price, dollars);
    strcat(price, ".");
    sprintf(cents, "%02ld", balance % 100);
    strcat(price, cents);
}

void insert_coin(struct vending_machine* machine, int coin) {
    machine->coin_count += 1;
    machine->coins[0] = coin;

    machine->balance += coin;

    char price[DISPLAY_LENGTH];
    presentBalance(machine->balance, price);
    strncpy(machine->display, price, sizeof(machine->display) - 1);
}

