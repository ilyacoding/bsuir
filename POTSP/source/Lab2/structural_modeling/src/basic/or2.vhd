library ieee;
use ieee.std_logic_1164.all;

entity or2 is
	port(
	A, B: in std_logic;
	R: out std_logic
	);
end or2;

architecture beh of or2 is
begin
	R <= A or B;
end;