from step_definitions import *

story.arrange()

story.act(insert_coin("nickel", machine))
story.act(insert_coin("dime", machine))
story.act(insert_coin("quarter", machine))