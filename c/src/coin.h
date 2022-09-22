

#ifndef VENDINGMACHINE_COIN_H
#define VENDINGMACHINE_COIN_H

static int coin_with_name(std::string name) {
    if (name == "penny") {
        return 1;
    }
    if (name == "nickel") {
        return 5;
    }
    if (name == "dime") {
        return 10;
    }
    if (name == "quarter") {
        return 25;
    }
    return 0;
}

#endif //VENDINGMACHINE_COIN_H
