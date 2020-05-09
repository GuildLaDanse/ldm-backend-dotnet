#!/bin/bash

SCRIPTDIR=`dirname "$BASH_SOURCE"`

source ${SCRIPTDIR}/Functions.sh
source ${SCRIPTDIR}/Environment.sh

#cd src/${MAIN_PROJECT}

PrintSectionHeader "Running project with watch"

exec dotnet watch --project src/${MAIN_PROJECT}/${MAIN_PROJECT}.csproj run
