library ieee;
use ieee.std_logic_1164.all;

entity xor2 is
	port(
	A, B: in std_logic;
	R: out std_logic
	);
end xor2;

architecture beh of xor2 is
begin
	R <= A xor B;
end;