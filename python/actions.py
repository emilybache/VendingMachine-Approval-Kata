
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