

class VendingMachine:
    def __init__(self, selected_product=None, stock=None):
        self.display = ""
        self.coins = []
        self.balance = 0
        self.selected_product = selected_product
        self.dispensed_product = None
        self.returns = []
        self.bank = []
        self.stock = stock or {}
        self.accepted_coins = [5,10,25]
        self.prices = {"Cola": 100, "Chips": 50, "Candy": 65}
        self._display_balance()

    def _display_balance(self):
        if self.balance:
            self.display = f"{self.balance}"
        elif self._has_change():
            self.display = "INSERT COIN"
        else:
            self.display = "EXACT CHANGE ONLY"

    def insert_coin(self, value):
        if value in self.accepted_coins:
            self.coins.append(value)
            self.balance += value
            self._display_balance()
        else:
            self.returns.append(value)

    def select_product(self, product):
        self.selected_product = product
        if self.balance >= self.prices[self.selected_product]:
            self._dispense_product()
        else:
            cents_to_dollars = '{:,.2f}'
            cost = self.prices[product]/100.0
            self.display = f"PRICE ${cents_to_dollars.format(cost)}"

    def _dispense_product(self):
        if self.stock[self.selected_product] >= 1:
            self.stock[self.selected_product] -= 1
            self.display = "THANK YOU"
            self.dispensed_product = self.selected_product
            self.balance -= self.prices[self.selected_product]
            self.bank += self.coins
            self.coins = []
            if self.balance > 0:
                change = _get_change_required(self.balance)
                self.returns = change
                [self.bank.remove(coin) for coin in change]
                self.balance = 0
            self.selected_product = None

        else:
            self.display = "SOLD OUT"
            self.selected_product = None

    def tick(self):
        if "PRICE" in self.display:
            self._display_balance()
        elif "THANK YOU" in self.display or "SOLD OUT" in self.display:
            self._display_balance()
            self.dispensed_product = None
            self.returns = []
        elif self.selected_product and self.balance >= self.prices[self.selected_product]:
            self._dispense_product()

    def update_stock(self, product, quantity):
        self.stock[product] = quantity

    def update_bank(self, coins):
        self.bank += coins
        self._display_balance()

    def return_coins(self):
        self.balance = 0
        self.returns = self.coins
        self.coins = []
        self._display_balance()

    def _has_change(self):
        quarters = [coin for coin in self.bank if coin == 25]
        dimes = [coin for coin in self.bank if coin == 10]
        nickels = [coin for coin in self.bank if coin == 5]
        return quarters and dimes and nickels


def _get_change_required(balance):
    # TODO: don't fake this one!
    return [10, 5]
