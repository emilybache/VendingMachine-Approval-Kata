
class VendingMachine:
    def __init__(self):
        self.display = ""
        self.coins = []
        self.returns = []
        self.balance = 0
        self.accepted_coins = [5,10,25]
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

    def return_coins(self):
        self.balance = 0
        self.returns = self.coins
        self.coins = []
        self._display_balance()
