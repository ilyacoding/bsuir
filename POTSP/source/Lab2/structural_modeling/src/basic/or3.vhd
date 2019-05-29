library ieee;
use ieee.std_logic_1164.all;

entity or3 is
	port(
	A, B, C: in std_logic;
	R: out std_logic
	);
end or3;

architecture struct of or3 is

component or2
	port(
	A, B: in std_logic;
	R: out std_logic
	);
end component;

signal or2_connector: std_logic;
begin
	U1:	or2 port map(A, B, or2_connector);
	U2: or2 port map(C, or2_connector, R);
end struct;