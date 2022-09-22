package org.codingdojo.vendingmachine;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.HashMap;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.assertArrayEquals;
import static org.junit.jupiter.api.Assertions.assertEquals;

public class VendingMachineTest {

    private VendingMachine machine;
    private Map<String, Integer> coins;

    @BeforeEach
    void setUp() {
        machine = new VendingMachine();
        coins = new HashMap<String, Integer>(){{
            put("penny", 1);
            put("nickel", 5);
            put("dime", 10);
            put("quarter", 25);
        }};
    }

    @Test
    public void test_accept_coins() {
        // TODO: use the printer and Approvals.verify instead of assertions

        assertEquals("INSERT COIN", machine.display());

        machine.insertCoin(coins.get("nickel"));

        assertEquals(5, machine.balance().intValue());
        assertArrayEquals(new Integer[]{5}, machine.coins());
        assertEquals("5", machine.display());
    }

}
