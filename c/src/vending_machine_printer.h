#ifndef VENDINGMACHINE_VENDING_MACHINE_PRINTER_H
#define VENDINGMACHINE_VENDING_MACHINE_PRINTER_H

#include "vending_machine.h"

// maximum buffer size
#define MAX_PRINT_LENGTH 20000
#define LINE_LENGTH 60

void
print_machine(const struct vending_machine* machine, char* buffer);

void
print_line(char *buffer, const char *key, const char *value);

void
print_coins(char* buffer, const int* coins, int coins_length);

int
buffer_size_for_coins(int coins_length);

#endif //VENDINGMACHINE_VENDING_MACHINE_PRINTER_H
