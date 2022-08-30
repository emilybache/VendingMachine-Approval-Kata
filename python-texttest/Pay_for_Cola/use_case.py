from step_definitions import *

machine.selected_product = "Cola"
story.arrange()

story.act(insert_coin("quarter", machine))
story.act(insert_coin("quarter", machine))
story.act(insert_coin("quarter", machine))
story.act(insert_coin("quarter", machine))
story.act(wait_5_secs(machine))
story.act(wait_5_secs(machine))