
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
        self._to_verify += self.printer.print_everything()

    def act(self, action):
        self._to_verify += action
        self._to_verify += "\n\n"
        self._to_verify += self.printer.print_significant_fields()

    def __str__(self):
        return self._to_verify


def select_product(product, machine):
    machine.select_product(product)
    return f"select product: {product}"


def wait_5_secs(machine):
    machine.tick()
    return "wait 5 seconds for display to refresh"


def insert_coin(coin_name, machine):
    machine.insert_coin(COINS[coin_name])
    return f"insert coin: {coin_name}"


def return_coins(machine):
    machine.return_coins()
    return "Return coins"

# These are initialized in the test_rig
machine = None
printer = None
story = None
