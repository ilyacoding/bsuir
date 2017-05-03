cmake_minimum_required(VERSION 3.7)
project(lab5)

set(CMAKE_C_STANDARD 99)

set(SOURCE_FILES main.c)

add_executable(lab5 ${SOURCE_FILES})
target_link_libraries(lab5 m)
target_link_libraries(lab5 pthread)

