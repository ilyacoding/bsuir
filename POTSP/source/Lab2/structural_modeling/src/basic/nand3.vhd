library ieee;
use ieee.std_logic_1164.all;

entity nand3 is
	port(
	A, B, C: in std_logic;
	R: out std_logic
	);
end nand3;

architecture struct of nand3 is

component and3
	port(
	A, B, C: in std_logic;
	R: out std_logic
	);
end component;

component inv
	port(
	A: in std_logic;
	nA: out std_logic
	);
end component;

signal original: std_logic;
begin
	U1:	and3 port map(A, B, C, original);
	U2: inv port map(original, R);
end struct;