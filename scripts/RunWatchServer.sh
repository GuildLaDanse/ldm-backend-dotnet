#!/bin/bash

SCRIPTDIR=`dirname "$BASH_SOURCE"`

source ${SCRIPTDIR}/Functions.sh
source ${SCRIPTDIR}/Environment.sh

cd ${MAIN_PROJECT}

PrintSectionHeader "Running project with watch"

exec dotnet watch run
