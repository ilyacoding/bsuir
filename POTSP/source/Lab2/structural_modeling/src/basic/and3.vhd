library ieee;
use ieee.std_logic_1164.all;

entity and3 is
	port(
	A, B, C: in std_logic;
	R: out std_logic
	);
end and3;

architecture struct of and3 is

component and2
	port(
	A, B: in std_logic;
	R: out std_logic
	);
end component;

signal and2_connector: std_logic;
begin
	U1:	and2 port map(A, B, and2_connector);
	U2: and2 port map(C, and2_connector, R);
end struct;