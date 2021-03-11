import pytest
from approvaltests import verify

from actions import select_product, wait_5_secs, insert_coin, return_coins
from vending_machine import VendingMachine
from vending_machine_printer import VendingMachinePrinter


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


@pytest.fixture()
def machine():
    return VendingMachine(stock={"Cola": 1, "Chips": 1, "Candy": 1})


@pytest.fixture
def printer(machine):
    return VendingMachinePrinter(machine)


@pytest.fixture
def story(printer):
    return Story(printer)


def test_accept_coins(machine: VendingMachine, story: Story):
    story.init("Feature: Accept coins")
    story.arrange()

    story.act(insert_coin("nickel", machine))
    story.act(insert_coin("dime", machine))
    story.act(insert_coin("quarter", machine))

    verify(str(story))


def test_reject_penny(machine: VendingMachine, story: Story):
    story.init("Feature: Reject penny")
    story.arrange()

    story.act(insert_coin("penny", machine))

    verify(str(story))


def test_select_product(machine : VendingMachine, story: Story):
    story.init("Feature: Select product and see price")
    story.arrange()

    story.act(select_product("Cola", machine))
    story.act(wait_5_secs(machine))
    story.act(select_product("Chips", machine))
    story.act(wait_5_secs(machine))

    verify(str(story))



def test_pay_for_product(machine : VendingMachine, story: Story):
    story.init("Feature: Pay for product")
    machine.selected_product="Cola"
    story.arrange()

    story.act(insert_coin("quarter", machine))
    story.act(insert_coin("quarter", machine))
    story.act(insert_coin("quarter", machine))
    story.act(insert_coin("quarter", machine))
    story.act(wait_5_secs(machine))
    story.act(wait_5_secs(machine))

    verify(str(story))


def test_pay_for_chips(machine : VendingMachine, story: Story):
    story.init("Feature: Pay for Chips")
    machine.selected_product="Chips"
    machine.insert_coin(25)
    story.arrange()
    story.act(insert_coin("quarter", machine))

    story.act(wait_5_secs(machine))
    story.act(wait_5_secs(machine))

    verify(str(story))


def test_pay_then_select_product(machine : VendingMachine, story: Story):
    story.init("Feature: Pay first then select product")
    machine.insert_coin(25)
    machine.insert_coin(25)
    machine.insert_coin(10)
    machine.insert_coin(5)
    story.arrange()

    story.act(select_product("Candy", machine))
    story.act(wait_5_secs(machine))

    verify(str(story))


def test_sold_out(machine : VendingMachine, story: Story):
    story.init("Feature: Sold out of Chips")
    machine.insert_coin(25)
    machine.insert_coin(25)
    machine.update_stock("Chips", 0)
    story.arrange()

    story.act(select_product("Chips", machine))
    story.act(wait_5_secs(machine))

    verify(str(story))


def test_return_coins(machine : VendingMachine, story: Story):
    story.init("Feature: Return Coins")
    machine.insert_coin(25)
    machine.insert_coin(10)
    story.arrange()

    story.act(return_coins(machine))

    verify(str(story))


def test_change_available(machine : VendingMachine, story: Story):
    story.init("Feature: Change is available")
    machine.update_bank([25, 25, 25, 25, 10, 10, 10, 10, 5, 5, 5, 5])
    story.arrange()

    verify(str(story))


def test_give_change(machine : VendingMachine, story: Story):
    story.init("Feature: Return change")
    machine.update_bank([25, 10, 5,])
    machine.insert_coin(25)
    machine.insert_coin(25)
    machine.insert_coin(25)
    story.arrange()

    story.act(select_product("Candy", machine))
    story.act(wait_5_secs(machine))

    verify(str(story))
