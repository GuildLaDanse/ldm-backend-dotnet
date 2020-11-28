#!/bin/bash

SECTIONCOLOR='\033[0;32m'
NC='\033[0m' # No Color

PrintSectionHeader ()
{
    printf "${NC}\n\n"
    printf "${SECTIONCOLOR}##################################################\n"
    printf "${SECTIONCOLOR}#\n"
    printf "${SECTIONCOLOR}# ${1}\n"
    printf "${SECTIONCOLOR}#\n"
    printf "${SECTIONCOLOR}##################################################\n"
    printf "${NC}\n"
}
