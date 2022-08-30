
COINS = {"penny": 1,
         "nickel": 5,
         "dime": 10,
         "quarter": 25}


class Story:
    def __init__(self, printer):
        self.printer = printer
        self._to_verify = ""

    def init(self, name):
        self._to_verify += name
        self._to_verify += "\n\n"

    def arrange(self):
        self._to_verify += self.printer.print()

    def act(self, action):
        self._to_verify += action
        self._to_verify += "\n\n"
        self._to_verify += self.printer.print()

    def __str__(self):
        return self._to_verify


def insert_coin(coin_name, machine):
    machine.insert_coin(COINS[coin_name])
    return f"insert coin: {coin_name}"




# These are initialized in the test_rig
machine = None
printer = None
story = None
