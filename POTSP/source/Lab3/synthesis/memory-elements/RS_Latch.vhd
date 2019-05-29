library IEEE;
use IEEE.STD_LOGIC_1164.all;

entity RS_Latch is
	port (
		R,S : in std_logic;
		Q, nQ : out std_logic
		);
end RS_Latch;

architecture struct of RS_Latch is
	component nor2 is
		port(
			A, B: in std_logic;
			R: out std_logic
			);
	end component;
	signal t1, t2 : std_logic;
begin
	U2: entity nor2(param) port map (A => R, B => t1, R => t2);
	U1: entity nor2(param) port map (A => S, B => t2, R => t1);
	nQ <= t1;
	Q <= t2;
end struct;

architecture beh of RS_Latch is
	signal t1, t2: std_logic;
begin
	t2 <= R nor t1;
	t1 <= S nor t2;
	nQ <= t1;
	Q <= t2;
end beh;

architecture param of RS_Latch is
	signal t1, t2: std_logic;
begin
	t2 <= R nor t1 after 3 ns;
	t1 <= S nor t2 after 3 ns;
	nQ <= transport t1 after 2 ns;
	Q <= transport t2 after 3 ns;
end param;