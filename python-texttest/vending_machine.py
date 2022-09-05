
class VendingMachine:
    def __init__(self, selected_product=None):
        self.display = ""
        self.coins = []
        self.returns = []
        self.balance = 0
        self.accepted_coins = [5,10,25]
        self.prices = {"Cola": 100, "Chips": 50, "Candy": 65}
        self.selected_product = selected_product
        self.dispensed_product = None
        self._display_balance()

    def _display_balance(self):
        if self.balance:
            self.display = f"{self.balance}"
        else:
            self.display = "INSERT COIN"

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
            cost = self.prices[product] / 100.0
            self.display = f"PRICE ${cents_to_dollars.format(cost)}"

    def _dispense_product(self):
        self.display = "THANK YOU"
        self.dispensed_product = self.selected_product
        self.balance -= self.prices[self.selected_product]
        self.coins = []
        self.selected_product = None

    def tick(self):
        """Simulate 5 seconds passing"""
        if "PRICE" in self.display:
            self._display_balance()
        elif "THANK YOU" in self.display:
            self._display_balance()
            self.dispensed_product = None
            self.returns = []
        elif self.selected_product and self.balance >= self.prices[self.selected_product]:
            self._dispense_product()
