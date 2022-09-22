
class VendingMachine:
    def __init__(self):
        self.display = ""
        self.coins = []
        self.balance = 0
        self._display_balance()

    def _display_balance(self):
        if self.balance:
            self.display = f"{self.balance}"
        else:
            self.display = "INSERT COIN"

    def insert_coin(self, value):
        self.coins.append(value)
        self.balance += value
        self._display_balance()

