#!/bin/bash

SCRIPTDIR=`dirname "$BASH_SOURCE"`

source ${SCRIPTDIR}/Functions.sh
source ${SCRIPTDIR}/Environment.sh

PrintSectionHeader "Running project with watch"

exec dotnet watch -p src/${MAIN_PROJECT}/${MAIN_PROJECT}.csproj run
