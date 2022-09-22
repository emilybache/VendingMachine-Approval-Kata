
#include <string.h>
#include <stdio.h>
#include "vending_machine_printer.h"

void
print_machine(const struct vending_machine* machine, char* buffer) {
    // TODO: print some useful values instead of these example keys and values
    char line1[LINE_LENGTH];
    char line2[LINE_LENGTH];
    print_line(line1, "Key", "Value");
    print_line(line2, "Other Key", "Another Value");

    sprintf(buffer, "%s\n%s%s", "VendingMachine", line1, line2);
}

void
print_line(char *buffer, const char *key, const char *value) {
    int whitespace_length = LINE_LENGTH - strlen(key) - strlen(value);
    char whitespace[whitespace_length];
    for (int i = 0; i < whitespace_length -1; ++i) {
        whitespace[i] = ' ';
    }
    whitespace[whitespace_length-1] = '\0';

    sprintf(buffer, "%s%s%s\n", key, whitespace, value );
}

void
print_coins(char* buffer, const int* coins, int coins_length) {
    // 4 chars for each coin plus zero termination
    int max_array_size = (coins_length)*4 + 1;
    char current_coin[5];
    char array_contents[max_array_size];
    for (int i = 0; i < coins_length; ++i) {
        snprintf(current_coin, 5, "%2d, ", coins[i]);
        if (i == 0) {
            strncpy(array_contents, current_coin, 5);
        } else {
            strncat(array_contents, current_coin, 5);
        }
    }

    array_contents[max_array_size -1] = '\0';

    sprintf(buffer, "{%s}", array_contents );
}

int
buffer_size_for_coins(int coins_length) {
    // two for {} plus termination plus 4 chars per coin
    return 3 + (coins_length * 4);
}

