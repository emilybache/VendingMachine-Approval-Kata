
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

void insert_coin(struct vending_machine* machine, int coin) {
    // TODO: write this code
}

