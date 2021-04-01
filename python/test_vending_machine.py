import pytest
from approvaltests import verify

from vending_machine import VendingMachine
from vending_machine_printer import VendingMachinePrinter


@pytest.fixture()
def machine():
    return VendingMachine()


@pytest.fixture
def printer(machine):
    return VendingMachinePrinter(machine)


@pytest.fixture
def coins():
    COINS = {"penny": 1,
             "nickel": 5,
             "dime": 10,
             "quarter": 25}
    return COINS


def test_accept_coins(machine: VendingMachine, printer: VendingMachinePrinter, coins: dict):
    # TODO: use the printer and approvaltests.verify instead of assertions

    assert machine.display == "INSERT COIN"

    machine.insert_coin(coins["nickel"])

    assert machine.balance == 5
    assert machine.coins == [5]
    assert machine.display == "5"


